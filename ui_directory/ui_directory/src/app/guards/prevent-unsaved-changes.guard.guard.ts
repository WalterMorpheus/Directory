import { CanActivateFn } from '@angular/router';

export const preventUnsavedChangesGuardGuard: CanActivateFn = (route, state) => {
  return true;
};
