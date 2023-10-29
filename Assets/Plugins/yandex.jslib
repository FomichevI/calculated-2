mergeInto(LibraryManager.library, {

   GetLanguage: function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lenghtBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  }

});