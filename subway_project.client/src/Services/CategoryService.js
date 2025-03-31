import axios from 'axios';

export const getCategories = async () => {
  try {
    const response = await axios.get("/api/Categories/");
    return response.data;
  } catch (error) {
    console.error('Error fetching categories:', error);
    throw error;
  }
};
