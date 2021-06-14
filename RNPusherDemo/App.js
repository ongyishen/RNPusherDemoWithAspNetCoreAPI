import { StatusBar } from "expo-status-bar";
import React from "react";
import { StyleSheet, Text, View, LogBox } from "react-native";
import { PusherProvider } from "@harelpls/use-pusher/react-native";

import ENV from "./env";
import PusherHelloWorld from "./components/PusherHelloWorld";
import PusherRandomNum from "./components/PusherRandomNum";

const config = {
  // required config props
  clientKey: ENV.pusherClientKey,
  cluster: ENV.pusherCluster,

  // optional if you'd like to trigger events. BYO endpoint.
  // triggerEndpoint: "/pusher/trigger",

  // required for private/presence channels
  // also sends auth headers to trigger endpoint
  authEndpoint: ENV.pusherCustomAuthEndPoint,
  // auth: {
  //   headers: { Authorization: "Bearer token" },
  // },
};

LogBox.ignoreLogs(["Setting a timer"]);

export default function App() {
  //console.log(ENV.pusherCustomAuthEndPoint);
  return (
    <PusherProvider {...config}>
      <View style={styles.container}>
        <Text>Pusher Demo + ASP.NET Core Web API</Text>
        <PusherHelloWorld></PusherHelloWorld>
        <PusherRandomNum></PusherRandomNum>
        <StatusBar style="auto" />
      </View>
    </PusherProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
