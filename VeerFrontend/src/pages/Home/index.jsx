import React from 'react'
import getLoggedInUser from '../../services/getLoggedInUser'
import { useLoaderData, useNavigate } from 'react-router-dom'
import InputField from '../../components/InputField';
import { useAuthContext } from '../../context/AuthContext';

const Home = () => {

const user = useLoaderData();
const authContext = useAuthContext();
const navigate = useNavigate();
const handleLogout = () => {
    authContext.logout();
    navigate('/');
}
  return (
    <div className='flex flex-col justify-center items-center space-y-3 pt-10'>
      <div className='flex flex-col justify-items-center w-full max-w-md px-4 space-y-4'>
    {Object.entries(user).map(([key, value]) => (
      <InputField
        type="text" 
        id={key} 
        isRequired={false} 
        disabled={true}
        label={key} 
        value={value}
        />
    ))}
    <button
        onClick={handleLogout}
        className='w-full bg-red-400 py-2 mt-6 rounded-xl hover:bg-red-600 transition duration-200'>
        Logout
      </button>
      </div>
  </div>
  )
}

export default Home

export const homePageLoader = async () => {
    console.log("fetching user data...");
    const response = await getLoggedInUser();
    return response
}