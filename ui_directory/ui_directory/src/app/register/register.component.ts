import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { ApplicationService } from '../services/application.service';
import { Application } from '../models/application';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup = new FormGroup({});
  validationErrors: string[] | undefined;
  applications: Application[] = [];
  selectedApplication: Application | null = null; 

  constructor(private userService: UserService,
    private fb: FormBuilder, private router: Router, 
    private applicationService: ApplicationService) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getApplications();
  }

  initializeForm(): void {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(32)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      customerName: ['', Validators.required], 
      applicationAlternateId: [-1, Validators.required]  
    });

    // Update confirmPassword validity when password changes
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    });
  }

  getApplications(): void {
    this.userService.getApplications().subscribe({
      next: (data) => {
        this.applications = data;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : { notMatching: true };
    };
  }

  register(): void {
    const values = { ...this.registerForm.value };

    // Map form values to match the new User model structure
    const user = {
      username: values.username,
      email: values.email,
      password: values.password,
      usercustomerapplications: [
        {
          applicationId: values.applicationAlternateId,
          customer: {
            name: values.customerName
          }
        }
      ]
    };

    this.userService.register(user).subscribe({
      next: () => {
        this.router.navigateByUrl('/dashboard');
      },
      error: error => {
        this.validationErrors = error;
      }
    });
  }

  cancel(): void {
    this.cancelRegister.emit(false);
  }
}
