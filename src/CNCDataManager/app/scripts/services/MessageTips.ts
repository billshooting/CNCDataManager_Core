
/**
 * 信息提示服务
 */
export default class MessageTips {
    public hideError: () => void;
    public showError: (msg: string) => void;
    public showLoading: () => void;
    public hideLoading: () => void;
    public showUpdate: (sequence: number, count: number, errorMsg?: string) => void;
    public constructor() {
        this.hideError = () => { };
        this.showError = msg => { };
        this.showLoading = () => { };
        this.hideLoading = () => { };
        this.showUpdate = (sequence, count, errorMsg?) => { };
    }
};