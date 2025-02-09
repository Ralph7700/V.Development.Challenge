import axios from 'axios';

const BASE_URL = import.meta.env.VITE_BASE_URL; 

/**
 * get the logged-in user's data.
 * @returns {Promise<{ id: string, email: string, userName: string, gender: string | null, dateOfBirth: string | null }>}
 * @throws {Object} - Problem Details object in case of an error.
 */

const getLoggedInUser = async () => {
  try {
    const {token} = JSON.parse(localStorage.getItem('auth'));

    if (!token) {
      throw {
        title: 'Authentication Error',
        detail: 'No token found in local storage',
        status: 401,
      };
    }

    const response = await axios.get(`${BASE_URL}/api/v1/users/logged-in`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.data);
    return response.data;

  } catch (error) {
    if (error.response) {
      throw error.response.data;
    } else {
      throw {
        title: 'Request Error',
        detail: error.message,
        status: 400,
      };
    }
  }
};

export default getLoggedInUser;