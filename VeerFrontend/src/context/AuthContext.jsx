import { createContext, useContext, useEffect, useState } from "react";

const AuthContext = createContext();

export const useAuthContext = () => {return useContext(AuthContext);}

export const AuthContextProvider = (props) =>{
    const [authUser, setAuthUser] = useState(JSON.parse(localStorage.getItem("auth")))
    const [isLoggedIn, setIsLoggedIn] = useState(false)

    
    const CheckUserAuth = () => {
        if(!authUser)return false
        const currentTime = new Date().getTime();
        const expirationTime = new Date(authUser.expiration).getTime();
        return currentTime < expirationTime;
    }

    useEffect(() => {
        setIsLoggedIn(CheckUserAuth());
    }, []);

    const login = (userData) => {
        localStorage.setItem("auth", JSON.stringify(userData));
        setAuthUser(userData);
        setIsLoggedIn(true);
    };

    const logout = () => {
        localStorage.removeItem("auth");
        setAuthUser(null);
        setIsLoggedIn(false);
    };

    return (
        <AuthContext.Provider value={{ authUser, isLoggedIn, login, logout }}>
            {props.children}
        </AuthContext.Provider>
    );
}