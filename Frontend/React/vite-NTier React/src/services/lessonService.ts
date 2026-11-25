import {ApiClient} from "./apiClient";
import type { LessonDTO } from "../types/lesson.types";

const lessonService = new ApiClient<LessonDTO>("/Lesson");
export default lessonService;