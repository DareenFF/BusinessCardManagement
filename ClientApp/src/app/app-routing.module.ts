import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateBusinessCardComponent } from './BusinessCard/create-business-card/create-business-card.component';
import { PreviewBusinessCardComponent } from './BusinessCard/preview-business-card/preview-business-card.component';
import { BusinessCardListComponent } from './BusinessCard/business-card-list/business-card-list.component';
import { AppComponent } from './app.component';


export const routes: Routes = [ // Default route
  { path: 'create', component:CreateBusinessCardComponent  },
  { path: 'preview', component:PreviewBusinessCardComponent  },
  { path: '', component:BusinessCardListComponent  } ,
  { path: '**', component: CreateBusinessCardComponent }// Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Configures the router at the app's root level
  exports: [RouterModule] // Exports RouterModule to be available throughout the app
})
export class AppRoutingModule { 


}
