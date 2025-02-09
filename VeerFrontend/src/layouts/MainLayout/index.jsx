import React from 'react'
import NavBar from '../NavBar'
import Footer from '../Footer'

const MainLayout = (props) => {
  return (
    <div className='min-h-screen flex flex-col'>

        <NavBar />

        <main className="flex-1 mb-16 relative">
        {/* Background */}
        <div 
          className="absolute inset-0 pointer-events-none"
          style={{
            backgroundImage: `repeating-linear-gradient(
                90deg,
                transparent,
                transparent 79px,
                rgba(229, 231, 235, 1) 79px,
                rgba(229, 231, 235, 1) 80px
              )`,
              backgroundSize: '80px 100%',
              maskImage: 'linear-gradient(to bottom, rgba(0,0,0,1) 0%, rgba(0,0,0,0) 50%, rgba(0,0,0,0) 100%)',
              WebkitMaskImage: 'linear-gradient(to bottom, rgba(0,0,0,1) 0%, rgba(0,0,0,0) 50%, rgba(0,0,0,0) 100%)',
          }}
        />
      
        {/* Content */}
        <div className='mt-16 z-10' >
          {props.children}
        </div>
      </main>

        <Footer />
        
    </div>
  )
}
export default MainLayout
