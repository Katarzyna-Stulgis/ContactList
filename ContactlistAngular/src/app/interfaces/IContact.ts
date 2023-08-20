import { IContactCategory } from "./IContactCategory"

export interface IContact {
    id: string
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    birthDate: Date,
    contactCategoryId: string,
    category: IContactCategory,
    subcategory?: string | null
}