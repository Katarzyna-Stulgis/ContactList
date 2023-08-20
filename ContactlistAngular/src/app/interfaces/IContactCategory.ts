import { IContactSubcategory } from "./IContactSubcategory";

export interface IContactCategory {
    id: string,
    name: string,
    contactSubcategories?: IContactSubcategory[] | null
}