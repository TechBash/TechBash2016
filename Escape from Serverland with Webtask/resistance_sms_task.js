var splunkBunyan = require("splunk-bunyan-logger");
var bunyan = require("bunyan");
var Logger = null;
var splunkStream = null;
var slack = null;
var twilio = require('twilio');

module.exports = function(ctx, req, res) {

// Uncomment below to use Splunk for logging.
/*
  initializeSplunkLogger(ctx);
*/

  // Some events cause Slack messages
  initializeSlack(ctx);
  
  // Pull out the SMS body
  var body = ctx.body.Body;
  
  // Create a Twilio response
  var twiml = new twilio.TwimlResponse();
  
  // If the body contains "911"
  if (body.indexOf("911") > -1)
  {
    // Tell the sender to sit tight
    twiml.message("Sit tight, we're coming for you");
    
    // send a slack alert
    slack.send({text:ctx.body.Body});
  }
  else {
    // nothing to do here, just return an ACK
    twiml.message("ACK");
  }
  
  // Uncomment below to use Splunk for logging.
  /*
  
  // send to Splunk the original message
  Logger.info(ctx.body);
  
  */
  // set the content-type for the Twilio response
  res.writeHead(200, {'Content-Type': 'text/xml'});
  // send the response
  res.end(twiml.toString());
};

function initializeSplunkLogger(ctx) {
  if (Logger === null) {
    //configure the Splunk logger using secrets
    var config = {
        token: ctx.secrets.token,
        url: ctx.secrets.host
    };
  
    splunkStream = splunkBunyan.createStream(config);
  
    Logger = bunyan.createLogger({
      name: "my logger",
      streams: [
          splunkStream
      ]
    });
  }
}

function initializeSlack(ctx) {
  if (slack === null) {
    // configure slack using secrets
    slack = require('slack-notify')(ctx.secrets.slack_webhook_url);
  }
}


