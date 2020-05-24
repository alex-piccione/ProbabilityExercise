import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component'
import { NavMenuComponent } from './nav-menu/nav-menu.component'
import { HomeComponent } from './home/home.component'
import { ProbabilityPage } from "./probability/probability.page"

// providers
import { BaseProvider } from "./providers/BaseProvider"
import { ProbabilityProvider } from "./providers/probability.provider"

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProbabilityPage
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'probability', component: ProbabilityPage },
      { path: '**', redirectTo: '' }
    ])
  ],
    providers: [
        ProbabilityProvider
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
