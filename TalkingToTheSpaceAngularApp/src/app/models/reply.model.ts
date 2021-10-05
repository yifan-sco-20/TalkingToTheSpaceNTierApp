import { User } from "./user.model";
export class Reply {
    reply_content: string;
    reply_status: string;
    reply_creation_date: Date;
    reply_modified_date: Date;
    reply_sent_date: Date;
    user_id: number;
    message_id:number;

    // user:User = new User();
}
