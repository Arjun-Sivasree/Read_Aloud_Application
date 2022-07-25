import React from "react";
import { Grid, Box } from "@mui/material";
import Body from "../Body/Body";

const Home = () => {
  return (
    <React.Fragment>
      <Box m={3}>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <Body />
          </Grid>
        </Grid>
      </Box>
    </React.Fragment>
  );
};

export default Home;
