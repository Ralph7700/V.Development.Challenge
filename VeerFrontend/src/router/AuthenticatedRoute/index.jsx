import React from 'react'
import { useAuthContext } from '../../context/AuthContext'
import { Navigate, Outlet } from 'react-router-dom';

const AuthenticatedRoute = () => {
    const {isLoggedIn} = useAuthContext();
  return (
    isLoggedIn ? <Outlet/> : <Navigate to="/login"/>
  )
}

export default AuthenticatedRoute