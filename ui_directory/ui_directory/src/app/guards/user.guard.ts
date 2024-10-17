import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { UserService } from '../services/user.service';
import { map } from 'rxjs';

export const userGuard: CanActivateFn = (route, state) => {
  const userService = inject(UserService);
  
  return userService.currentUser$.pipe(
    map(user => {
     if(user) return true;
     else{
       return false;
     }
    })
   );
};
