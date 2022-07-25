import axios from "axios";

const _axios = axios.create({
  baseURL: "https://localhost:5001/Member/",
  headers: {
    "content-type": "application/json",
  },
});

const urls = {
  GetMembersAndAssignment: "MembersAndAssignments",
  Register: "MemberAndPersonalData",
};

//gets member details and assignments assigned to them with due date
export async function getAllMembersAndAssignments() {
  let response = await _axios.get(urls.GetMembersAndAssignment);
  return response;
}

//register a new member
export async function RegisterNewMember(body) {
  let response = await _axios.post(urls.Register, body);
  return response;
}
