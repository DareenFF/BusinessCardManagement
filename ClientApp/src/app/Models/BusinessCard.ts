export interface BusinessCard {
    id?: number; // Primary Key
    name?: string; // Optional Name of the cardholder
    gender?: "Male | Female"; // Optional Gender of the cardholder
    dob?: Date; // Date of Birth (use Date type for handling dates)
    email?: string; // Optional Email of the cardholder
    phone?: string; // Optional Phone number of the cardholder
    address?: string; // Optional Address of the cardholder
    photo?: string; // Optional Photo of the cardholder (string for base64 representation)
}
