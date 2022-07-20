import React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";

const AssignmentTable = (props) => {
  return (
    <TableContainer>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Topic</TableCell>
            <TableCell>Submission Date</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.assignment.map((element, index) => (
            <TableRow key={element.id}>
              <TableCell>{element.description}</TableCell>
              <TableCell>{element.submissionDate}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default AssignmentTable;
