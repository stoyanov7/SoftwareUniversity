/**
 * Class that holds data about an HTTP request.
 */
class Request {
     constructor(method, uri, version, message) {
          this._method = method;
          this._uri = uri;
          this._version = version;
          this._message = message;
          this._response = undefined;
          this._fulfilled = false;
     }
}