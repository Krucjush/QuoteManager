import { Routes } from '@angular/router';
import { provideRouter } from '@angular/router';
import { Quotes } from './components/quotes/quotes';

export const routes: Routes = [
    { path: '', redirectTo: '/quotes', pathMatch: 'full' },
    { path: 'quotes', component: Quotes},
];

export const appRouter = provideRouter(routes);