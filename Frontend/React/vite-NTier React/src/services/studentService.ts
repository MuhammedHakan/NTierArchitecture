import { ApiClient } from './apiClient';
import type { StudentDTO } from '../types/student.types';

const studentService = new ApiClient<StudentDTO>('/Student');
export default studentService;
