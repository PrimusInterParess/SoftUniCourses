const { PORT, DB_NAME, DB_CONNECTION } = process.env;

module.exports = {
  port: PORT || 3005,
  dbConnection: `${`mongodb://localhost:27017`}/${`user-list`}`,
};
