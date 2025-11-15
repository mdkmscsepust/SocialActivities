import { Routes } from '@angular/router';
import { DonetItemComponent } from '../donet-item/donet-item.component';
import { ReceiveItemComponent } from '../receive-item/receive-item.component';

export const routes: Routes = [
    {component: DonetItemComponent, path: ''},
    {component: ReceiveItemComponent, path: 'receive'}
];
