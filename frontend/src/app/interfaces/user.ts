import { DatePersonale } from "./date_personale";

export interface User{

  Nume_Utilizator?: string;
  Prenume_Utilizator?: string;
  Parola_Hashed: string;
  Date_Personale?: DatePersonale;
  Total_Puncte?: number,
  Username: string,
  Rol?: number
}
