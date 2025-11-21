import { Routes } from '@angular/router';
import { DonetItemComponent } from '../donet-item/donet-item.component';
import { ReceiveItemComponent } from '../receive-item/receive-item.component';
import { authRoutes } from './auth/auth.routes';

export const routes: Routes = [
    {component: DonetItemComponent, path: ''},
    {component: ReceiveItemComponent, path: 'receive'},
    {
        path: 'auth',
        children: authRoutes
    }
];
