import { Phone, X } from 'lucide-react';
import React, { useState } from 'react'
import CustomerSupportIcon from "../../assets/CustomerSupportIcon.svg"

const NavBar = () => {
  const [isVisible, setIsVisible] = useState(true);

  if (!isVisible) {
    return null;
  }

  const handleCallSupport = () => {
    alert('Calling support...');
  };

  return (
    <div className="fixed top-0 left-0 right-0 bg-white shadow-sm text-veer-grey z-20">
      <div className="max-w-7xl mx-auto px-4 ">
        <div className="flex items-center justify-end h-16 space-x-4">
          <div className="flex items-center space-x-4">
            <span >Need help?</span>
            <button 
              onClick={handleCallSupport}
              className="flex items-center space-x-2 bg-white  border-2 border-gray-200
              hover:bg-gray-50 px-4 py-2 rounded-xl transition-colors"
            >
                <img src={CustomerSupportIcon} alt="phone" className="w-5 h-5" />
              <span >Contact Us</span>
            </button>

            {/* Close Button */}
            <button 
              onClick={() => setIsVisible(false)}
              className="p-2 rounded-xl hover:bg-gray-100 transition-colors"
              aria-label="Close navigation"
            >
              <X size={20}  />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NavBar;
