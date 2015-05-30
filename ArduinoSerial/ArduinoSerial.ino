void processCommand(String command) {
      if (command == "turn on 13") {
        digitalWrite(13, HIGH);
        Serial.println("13 turned on");
        return;
      }
        
      if (command == "turn off 13") {
        digitalWrite(13, LOW);
        Serial.println("13 turned off");
        return;
      }
      
      if (command == "turn on led") {
        analogWrite(9, 255);
        Serial.println("led turned on");
        return;
      }
      
      if (command == "turn off led") {
        analogWrite(9, 0);
        Serial.println("led turned off");
        return;
      }
      
      if (command == "read light") {
        Serial.println(analogRead(0));
        return;
      }
        
       if (command == "sleep") {
         Serial.println("sleeping");
         return;
       }
       
       Serial.print("unknown command: ");
       Serial.println(command);
}

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available()) {
    String command;
    command = Serial.readString();
    processCommand(command);
  }
}