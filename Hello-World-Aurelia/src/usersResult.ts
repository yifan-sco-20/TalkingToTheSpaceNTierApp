import { User } from "user";
import { Iresult } from "iresult";

export class UserResult implements Iresult {
    success: boolean;
    userMessage: string;
    user_set:User[]=[];
}
