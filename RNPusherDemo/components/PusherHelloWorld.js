import React, { useState } from "react";
import { StyleSheet, Text, View, LogBox } from "react-native";
import { useChannel, useEvent } from "@harelpls/use-pusher/react-native";

export default function PusherHelloWorld() {
  const [counter, setCounter] = useState(0);
  const channel = useChannel("private-my-channel");
  const eventName = "my-event";

  //Subscribe to event
  useEvent(channel, eventName, ({ message }) => {
    if (message === "hello world") {
      setCounter(counter + 1);
    }
  });

  return (
    <View style={styles.containter}>
      <Text>Hello World Counter : {counter}</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  containter: {
    marginVertical: 10,
  },
});
