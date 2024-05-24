export interface ApiResponse<T> {
    result: boolean;
    data: T;
    message: string;
  }
