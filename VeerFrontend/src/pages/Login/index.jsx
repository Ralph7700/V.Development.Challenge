import React, { useState } from 'react'
import LoginIcon from '../../assets/LoginIcon.svg'
import EmailIcon from '../../assets/EmailIcon.svg'
import PasswordIcon from '../../assets/PasswordIcon.svg'
import InputField from '../../components/InputField'
import { NavLink, useNavigate } from 'react-router-dom'
import loginRequest from '../../services/loginRequest'
import { useAuthContext } from '../../context/AuthContext'

const Login = () => {
    const navigate = useNavigate();
    const {login} = useAuthContext();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        // Validate email
        if (!email) {
          setError('Email is required' );
          return
        } else if (!/\S+@\S+\.\S+/.test(email)) {
          setError('Email is invalid');
          return
        }
        
        // Validate password
        if (!password) {
          setError('Password is required');
          return
        } else if (password.length < 8) {
          setError('Password must be at least 8 characters');
          return
        }
        
        //Call Login Api
        if (email && password) {
          console.log('Form submitted successfully:', { email, password });
          handleLoginRequest(email,password);
        }
      };

    const handleLoginRequest = async (email, password) => {
        try {
            const response = await loginRequest(email, password);
            login(response);
            console.log('Login successful:', response);
            navigate("/home")
                
          } catch (error) {
            console.error('Login failed:', error);
            setError(error.detail || error.type || "Something went wrong");
          }
    }

  return (
    <div className='flex flex-col justify-center items-center space-y-3 pt-10'>
      <div className='flex flex-col justify-items-center w-full max-w-md px-4'>
        <img src={LoginIcon} alt='login-icon' className='mx-auto' />
        <h1 className='text-3xl mb-3 text-center'>Login</h1>
        <span className='text-veer-gray text-center'>Enter your details to login.</span>

          {error && <span className='text-red-500 text-sm text-center mt-5'>{error}</span>}
        <form className='w-full mt-6 space-y-4' onSubmit={handleSubmit}>

          <InputField 
            type="text" 
            id='email' 
            isRequired={true} 
            label='Email' 
            iconSrc={EmailIcon}
            placeholder='test@test.com'
            value={email}
            onChange={setEmail}
        />

            <InputField 
                type="password" 
                id='password' 
                isRequired={true} 
                label='Password' 
                iconSrc={PasswordIcon}
                placeholder='Enter you password'
                value={password}
                onChange={setPassword}
            />

          
          {/* Submit Button */}
          <button
            type='submit'
            className='w-full bg-veer-green py-2 rounded-xl hover:bg-green-600 transition duration-200'
          >
            Login
          </button>
        </form>

        <p className='text-center mt-4 text-sm text-veer-gray'>
          Already have an account? <NavLink to='/signup' className='text-veer-green hover:underline'>Signup</NavLink>
        </p>
      </div>
    </div>
  );
};

export default Login;