import { User } from "./user.model";
import { Iresult } from "../interfaces/iresult";

export class UserResult implements Iresult {
    success: boolean;
    userMessage: string;
    user_set:User[]=[];
}
