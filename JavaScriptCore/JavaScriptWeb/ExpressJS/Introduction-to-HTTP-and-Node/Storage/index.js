const storage = require('./storage');

storage.put('First', "Player")
storage.save();
storage.load();

storage.put('Second', "Player")
storage.save();
storage.load();
