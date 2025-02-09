import axios from 'axios';
const BASE_URL = import.meta.env.VITE_BASE_URL; 

/**
 * Login request.
 * @param {string} email 
 * @param {string} password 
 * @returns {Promise<{ token: string, expiration: string }>} 
 * @throws {Object} - Problem Details object in case of an error.
*/
const loginRequest = async (email, password) => {
  try {
    const response = await axios.post(`${BASE_URL}/api/v1/auth/login`, {
      email,
      password,
    });
    
    return response.data;
  } catch (error) {
    if (error.response) {
      throw error.response.data;
    } 
    else {
      throw {
        title: 'Request Error',
        detail: error.message,
        status: 400
      };
    }
  }
};

export default loginRequest