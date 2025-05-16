export interface ValidationResult {
  isValid: boolean;
  errorMessage: string;
}

export const validateString = (
  value: string,
  rules: {
    required?: boolean;
    minLength?: number;
    maxLength?: number;
    pattern?: RegExp;
  }
): ValidationResult => {
  if (rules.required && !value) {
    return {
      isValid: false,
      errorMessage: "Это поле обязательно для заполнения.",
    };
  }
  if (rules.minLength && value.length < rules.minLength) {
    return {
      isValid: false,
      errorMessage: `В этом поле должно быть не менее ${rules.minLength} символов.`,
    };
  }
  if (rules.maxLength && value.length > rules.maxLength) {
    return {
      isValid: false,
      errorMessage: `В этом поле должно быть не более ${rules.maxLength} символов.`,
    };
  }
  if (rules.pattern && !rules.pattern.test(value)) {
    return { isValid: false, errorMessage: "Неверный формат поля." };
  }
  return { isValid: true, errorMessage: "" };
};

export const validatePasswords = (
  value1: string,
  value2: string
): ValidationResult => {
  if (value1 !== value2) {
    return { isValid: false, errorMessage: "Пароли не совпадают." };
  }
  return { isValid: true, errorMessage: "" };
};
