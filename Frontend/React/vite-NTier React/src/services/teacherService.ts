import type { TeacherDTO } from "../types/teacher.types";
import { ApiClient } from "./apiClient";

const teacherService = new ApiClient<TeacherDTO>("/Teacher");
export default teacherService;