
/**
 * 信息提示服务
 */
export default class MessageTips {
    public hideError: () => void;
    public showError: (msg: string) => void;
    public showLoading: () => void;
    public hideLoading: () => void;
    public showUpdate: (sequence: number, count: number, errorMsg?: string) => void;
};