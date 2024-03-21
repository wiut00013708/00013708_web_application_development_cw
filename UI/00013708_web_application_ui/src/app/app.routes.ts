import { Routes } from '@angular/router';
import { NumbersComponent } from './components/numbers/numbers.component';
import { CreateComponent } from './components/create/create.component';
import { DetailsComponent } from './components/details/details.component';
import { EditComponent } from './components/edit/edit.component';
import { DeleteComponent } from './components/delete/delete.component';

export const routes: Routes = [
    {
        path: "",
        component: NumbersComponent
    },

    {
        path: "numbers",
        component: NumbersComponent
    },

    {
        path: "create",
        component: CreateComponent
    },

    {
        path: "details/:id",
        component: DetailsComponent
    },
    {
        path: "edit/:id",
        component: EditComponent
    },
    {
        path: "delete/:id",
        component: DeleteComponent
    }
];
