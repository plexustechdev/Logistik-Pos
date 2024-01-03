mergeInto(LibraryManager.library, {
  GetBaseUrl: function () {
    var returnUrl = baseUrl;
    var bufferSize = lengthBytesUTF8(returnUrl) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnUrl, buffer, bufferSize);
    return buffer;
  },
});
