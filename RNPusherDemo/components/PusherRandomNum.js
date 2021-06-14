import React, { useState } from "react";
import { StyleSheet, Text, View, LogBox } from "react-native";
import { useChannel, useEvent } from "@harelpls/use-pusher/react-native";

export default function PusherRandomNum() {
  const [number, setNumber] = useState(0);
  const channel = useChannel("private-my-channel");
  const eventName = "my-random-number";

  //Subscribe to event
  useEvent(channel, eventName, ({ number }) => {
    if (number >= 0) {
      setNumber(number);
    }
  });

  return (
    <View style={styles.containter}>
      <Text>Lucky Number : {number}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  containter: {
    marginVertical: 10,
  },
});
