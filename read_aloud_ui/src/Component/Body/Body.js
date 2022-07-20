import React, { useState, useEffect } from "react";
import { Grid } from "@mui/material";
import MemberTable from "../MemberTable/MemberTable";
import AssignmentTable from "../AssignmentTable/AssingmentTable";
import { getAllMembersAndAssignments } from "../Axios/_axios";

const Body = () => {
  const [memberData, setMemberData] = useState([]);
  const [assignment, setAssignment] = useState([]);

  //to load initial data table with member details
  useEffect(() => {
    const loadMemberAndAssignments = async () => {
      try {
        let response = await getAllMembersAndAssignments();

        if (response !== undefined) {
          if (response.status === 200) {
            console.log(response.data);
            setMemberData(response.data);
          }
        }
      } catch (error) {
        console.log(error);
      }
    };

    loadMemberAndAssignments();
  }, []);

  const handleTableRowClick = (index) => {
    setAssignment(memberData[index].assignments);
  };

  return (
    <React.Fragment>
      <Grid container spacing={2}>
        <Grid item xs={4}>
          <MemberTable
            memberData={memberData}
            handleTableRowClick={handleTableRowClick}
          />
        </Grid>
        <Grid item xs={4}>
          <AssignmentTable assignment={assignment} />
        </Grid>
      </Grid>
    </React.Fragment>
  );
};

export default Body;
