import React from 'react'
import { Navigate } from 'react-router-dom';
import { useAuthContext } from '../../context/AuthContext';

const BaseRouteRedirect = () => {
    const {isLoggedIn} = useAuthContext();
    return (
      isLoggedIn ? <Navigate to="/home"/> : <Navigate to="/login"/>
    )
}

export default BaseRouteRedirect