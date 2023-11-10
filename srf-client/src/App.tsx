import {
  defaultTheme,
  Admin,
  Resource,
  ShowGuesser,
  ListGuesser,
} from "react-admin";
import { BrowserRouter } from "react-router-dom";
import stageRaceResourceProps from "./StageRaces";
import dataProvider from "./dataProvider";

const theme = {
  ...defaultTheme,
  palette: {
    primary: { main: "#00898F" },
    secondary: { main: "#00898F" },
    text: { faded: "#696969" },
  },
};

const App = () => {
  return (
    <BrowserRouter>
      <Admin
        theme={theme}
        dataProvider={dataProvider}
        title="Stage Race Fantasy"
      >
        <Resource
          {...stageRaceResourceProps}
          list={ListGuesser}
          show={ShowGuesser}
        />
      </Admin>
    </BrowserRouter>
  );
};

export default App;
