import { Iresult } from "../interfaces/iresult";
import { Message } from "./message.model";

export class MessageResult implements Iresult {
    success: boolean;
    userMessage: string;
    message_set: Message[] = [];
}
