import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

const LOCAL_STORAGE_KEY = 'token';
@Injectable({
    providedIn: 'root'
})

export class TokenService {
    private jwtHelper: JwtHelperService = new JwtHelperService();

    constructor() { }

    public GetToken():any {
        return localStorage.getItem(LOCAL_STORAGE_KEY);
    }

    public SaveToken(token: string): void {
        localStorage.setItem(LOCAL_STORAGE_KEY, `Bearer ${token}`);
    }

    public RemoveToken(): void {
        localStorage.removeItem(LOCAL_STORAGE_KEY);
    }

    public GetTokenExpiration() {
        return this.jwtHelper.getTokenExpirationDate(this.GetToken());
    }

    public isTokenExpired(): boolean {
        return this.jwtHelper.isTokenExpired(this.GetToken());
    }

    public DecodeToken(): any {
        return this.jwtHelper.decodeToken(this.GetToken());
    }

    public GetTokenValue(key: string): string {
        const decodeObj = this.DecodeToken();
        return decodeObj[key];
    }
}