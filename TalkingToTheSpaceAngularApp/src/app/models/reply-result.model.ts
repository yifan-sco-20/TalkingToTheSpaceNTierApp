import { Reply } from "./reply.model";
import { Iresult } from "../interfaces/iresult";
export class ReplyResult implements Iresult {
    success: boolean;
    userMessage: string;
    reply_set:Reply[]=[];
}
