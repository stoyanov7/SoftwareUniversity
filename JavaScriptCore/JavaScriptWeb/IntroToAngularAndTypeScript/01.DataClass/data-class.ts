class DataRequest {
    method: string;
    url: string;
    version: string;
    message: string;
    response: string;
    fulfilled: boolean;

    constructor(method: string, url: string, version: string, message: string) {
        this.method = method;
        this.url = url;
        this.version = version;
        this.message = message;
        this.response = 'undefined';
        this.fulfilled = false;
    }
}

let myData = new DataRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData);