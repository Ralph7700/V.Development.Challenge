import React from 'react'

// text field reusable component
const InputField = (props) => {
    //props: label - id - isRequired - iconSrc - type - placeholder - value - onChange
  return (
    <div className='flex flex-col space-y-2'>
        {props.label && <label htmlFor={props.id} className='text-sm font-medium'>
            {props.label} {props.isRequired && <span className='text-veer-green'>*</span>}
        </label>}
        <div className='flex items-center border border-gray-300 rounded-xl focus-within:ring-2 focus-within:ring-veer-green'>
            {props.iconSrc && <img src={props.iconSrc} alt={`${props.id}-icon`} className='w-5 h-5 ml-3' />}
            <input
            disabled={props.disabled || false}
            type={props.type}
            id={props.id}
            placeholder={props.placeholder}
            className='w-full p-1 m-1 focus:outline-none'
            value={props.value}
            onChange={(e) => props.onChange(e.target.value)}
            />
        </div>
    </div>
  )
}

export default InputField