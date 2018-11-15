void setup() {
  // put your setup code here, to run once:
  pinMode(13,OUTPUT);
  Serial.begin(9600);
  
}

void loop() {
  // put your main code here, to run repeatedly:
  int tmp;
  char r[8];
  int rr[8];
  int pn,i=0;
  r[0] = '/';
  //Serial.print('1');
  if(Serial.available()>0){
    while(i!=8){
      if(Serial.available()>0){
        r[i] = Serial.read();
        ++i;
      }
    }
  }
  
  switch(r[0]){
    case 'a':
      //デジタル出力
      rr[1] = int(r[1])-48;
      rr[2] = int(r[2])-48;
      pn = rr[1] *10 + rr[2];
      if(r[3] == 'h'){
        digitalWrite(pn,HIGH);
      }else{
        digitalWrite(pn,LOW);
      }
      break;
    case 'b':
      //デジタル入力
      rr[1] = int(r[1])-48;
      rr[2] = int(r[2])-48;
      pn = rr[1] *10 + rr[2];
      tmp = digitalRead(pn);
      Serial.println(tmp);
      break;
    case 'c':
      //アナログ入力
      rr[1] = int(r[1])-48;
      rr[2] = int(r[2])-48;
      pn = rr[1] *10 + rr[2];
      tmp = analogRead(pn);
      Serial.println(tmp);
      break;
    case 'd':
      //PWM出力
      rr[1] = int(r[1]) -48;
      rr[2] = int(r[2]) -48;
      rr[3] = int(r[3]) -48;
      rr[4] = int(r[4]) -48;
      rr[5] = int(r[5]) -48;
      pn = rr[1] *10 + rr[2];
      
      tmp = rr[3] * 100 + rr[4] * 10 + rr[5];
      
      //Serial.print(rr[5]);
      analogWrite(pn,tmp);
      break;
      
  }
}


