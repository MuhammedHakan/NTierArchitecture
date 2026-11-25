import type { ClassDTO } from '../types/class.types';
import { ApiClient } from './apiClient';

// Generic client'tan Class servisi – tek satır!
const classService = new ApiClient<ClassDTO>('/Class');

export default classService;

