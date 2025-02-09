import React from 'react'
import { useRouteError } from 'react-router-dom'

const ErrorElement = () => {
    const error = useRouteError()
    return (
      <div className=' flex flex-col justify-center items-center h-screen'>
        <h1 className='text-3xl'>Something Whent Wrong 😵</h1>
        <span>{error.type}</span>
      </div>
      );
}

export default ErrorElement