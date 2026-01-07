import axios from 'axios';

const API_BASE_URL = 'http://localhost:5298/api/tasks';

export const getTasks = async () => {
  const response = await axios.get(API_BASE_URL);
  return response.data;
};

export const createTask = async (task) => {
  const response = await axios.post(API_BASE_URL, task);
  return response.data;
};

export const updateTaskStatus = async (taskId, status) => {
  const response = await axios.patch(`${API_BASE_URL}/${taskId}/status`, { status: status });
  return response.data;
};

export const deleteTask = async (taskId) => {
  const response = await axios.delete(`${API_BASE_URL}/${taskId}`);
  return response.data;
};