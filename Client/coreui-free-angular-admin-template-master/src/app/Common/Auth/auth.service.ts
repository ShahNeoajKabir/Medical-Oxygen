
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenService } from './token.service';
import { VMLogin } from '../../Model/VMLogin';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
//   applicationUrl: string = "https://localhost:44310/api/";
// httpOptions = {
// headers: new HttpHeaders({ 'Content-Type': 'application/json' })
// };
  
  url="http://localhost:54667/api/Security/";

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private router: Router
  ) { }


  login(authData: VMLogin) {
    console.log("Find");
    const body = {
      Email: authData.Email,
      Password: authData.Password
    };
    return this.http.post(this.url+"Login", body).pipe(map((res: any) => {
      const loginData = res;
      this.tokenService.SaveToken(loginData);
      
    }));

  }

  public removeToken() {
    this.tokenService.RemoveToken();
    this.router.navigate(['Login']);
  }

  checkLogged() {
    if (this.tokenService.GetToken()) {
      return !this.tokenService.isTokenExpired();
    } else {
      return false;
    }
  }
  getLoggedUsername() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('unique_name');
    }
    return '';
  }

  getLoggedUserType(): number {
    if (this.tokenService.GetToken()) {
      return  Number(this.tokenService.GetTokenValue('user_type'));
    }
    return 0;
  }

  getLoggedEmail() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('Email');
    }
    return '';
  }
  getLoggedUserId() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('userid');
    }
    return '';
  }
  getUserRole() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('Role');
    }
    return '';
  }
  
}
